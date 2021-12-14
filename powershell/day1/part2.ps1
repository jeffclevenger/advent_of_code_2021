# $a=0;
# $i=1; 
#These are set like this bc I dont know how to null out the array so i have to mess with the starting numbers to take into account the looping

$a=1; $i=0; ($foo = Get-Content -Path .\input.txt -Stream $DATA) | % {$a++; if(($foo[$a] + $foo[($a-1)] + $foo[($a+1)]) -gt ($foo[($a)] + $foo[($a+1)] + $foo[($a+2)]))  {$i++} }; write-host $i