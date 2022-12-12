$session = [Microsoft.PowerShell.Commands.WebRequestSession]::new()

$cookie = [System.Net.Cookie]::new('session', '')
$session.Cookies.Add('https://adventofcode.com', $cookie)

$input = Invoke-WebRequest 'https://adventofcode.com/2019/day/1' -WebSession $session


$response = Invoke-WebRequest 'https://adventofcode.com/2022/day/3/answer' -Body @{level = "1"; answer = "8298"} -WebSession $session -Method Post