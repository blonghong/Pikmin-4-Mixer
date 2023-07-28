cd C:\Users\booge\Desktop\vgmstream
for /f %%f in ('dir /b %1') do vgmstream-cli.exe -o "%1\%%f.wav" "%1\%%f"
pause