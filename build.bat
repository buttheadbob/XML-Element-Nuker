dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true


"%~dp0bin\Release\net10.0\win-x64\publish\XmlElementNuker.exe"

