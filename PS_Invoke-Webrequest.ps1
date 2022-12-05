$session = [Microsoft.PowerShell.Commands.WebRequestSession]::new()

$cookie = [System.Net.Cookie]::new('session', '53616c7465645f5f92108aa9823b64a0fe20c4e2a7dd8d5f9d846d14a1eaf57405dd348891463f348cb117c5ed8f021e5ad70f0279b897416c98f30afb7030c7')
$session.Cookies.Add('https://adventofcode.com', $cookie)

$input = Invoke-WebRequest 'https://adventofcode.com/2019/day/1' -WebSession $session


$response = Invoke-WebRequest 'https://adventofcode.com/2022/day/3/answer' -Body @{level = "1"; answer = "8298"} -WebSession $session -Method Post