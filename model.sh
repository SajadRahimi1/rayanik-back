touch "Models/$1.cs"
echo "public class $1Repository : BaseEntity\n{\n\n}" > "Models/$1.cs"