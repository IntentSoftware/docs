Start-Process "http://localhost:8080/"
Start-Process "./_tools/DocFX/docfx" -Wait -NoNewWindow -ArgumentList "docfx.json", "--serve"
