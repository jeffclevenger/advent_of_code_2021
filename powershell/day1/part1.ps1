# $a=0;
# $i=1; 
#These are set like this bc I dont know how to null out the array so i have to mess with the starting numbers to take into account the looping

$a=0; $i=1; ($foo = Get-Content -Path .\input.txt -Stream $DATA) | % {$a++; if($foo[$a] -gt $foo[($a-1)]) {$i++} }; write-host $i