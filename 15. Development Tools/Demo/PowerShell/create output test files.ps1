for($i = 1; $i -lt 21; $i++) {
	$fileName = [string]::Format("test.{0:000}.out.txt", $i)
	New-Item $fileName -type file
	Write-Output $fileName
}