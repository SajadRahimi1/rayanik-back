using System.Security.Cryptography;

public static class FileEncryption
{
    public static void EncryptFileWithKey(string inputFile, string outputFile, Guid encryptionKey)
    {
        int chunkSize = 1024 * 1024; // 1MB chunk size
        byte[] keyBytes = encryptionKey.ToByteArray();
        byte[] paddedKey = new byte[32]; // Assuming the encryption algorithm requires a 256-bit key (32 bytes)

        Array.Copy(keyBytes, paddedKey, Math.Min(keyBytes.Length, paddedKey.Length));

        using (FileStream inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
        using (FileStream outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
        {
            int numChunks = (int)Math.Ceiling((double)inputStream.Length / chunkSize);

            // Use CountdownEvent to track completion of all threads
            using (CountdownEvent countdownEvent = new CountdownEvent(numChunks))
            {
                for (int i = 0; i < numChunks; i++)
                {
                    int chunkIndex = i;
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        int startOffset = chunkIndex * chunkSize;
                        int endOffset = Math.Min(startOffset + chunkSize, (int)inputStream.Length);

                        byte[] chunk = new byte[endOffset - startOffset];
                        inputStream.Seek(startOffset, SeekOrigin.Begin);
                        inputStream.Read(chunk, 0, chunk.Length);

                        byte[] encryptedChunk;
                        using (Aes aes = Aes.Create())
                        {
                            aes.Key = paddedKey;
                            aes.Mode = CipherMode.CBC;
                            aes.Padding = PaddingMode.PKCS7;

                            aes.GenerateIV();
                            byte[] iv = aes.IV;

                            using (ICryptoTransform encryptor = aes.CreateEncryptor())
                            using (MemoryStream encryptedStream = new MemoryStream())
                            using (CryptoStream cryptoStream = new CryptoStream(encryptedStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(chunk, 0, chunk.Length);
                                cryptoStream.FlushFinalBlock();
                                encryptedChunk = encryptedStream.ToArray();
                            }

                            byte[] encryptedBytes = new byte[iv.Length + encryptedChunk.Length];
                            Array.Copy(iv, encryptedBytes, iv.Length);
                            Array.Copy(encryptedChunk, 0, encryptedBytes, iv.Length, encryptedChunk.Length);

                            // Write encrypted bytes to output file
                            lock (outputStream)
                            {
                                outputStream.Seek(startOffset, SeekOrigin.Begin);
                                outputStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                            }
                        }

                        countdownEvent.Signal(); // Signal completion of the thread
                    });
                }

                countdownEvent.Wait(); // Wait for all threads to complete
            }
        }
    }
}