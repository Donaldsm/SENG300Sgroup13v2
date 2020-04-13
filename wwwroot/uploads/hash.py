def f(y1,y2):
	return (y1 * y1 + y2 * y2 + 11) % 15
	
def displayNum(num):
	return str(num) + '(' + format(num, 'b') + ')'
	
def printStep(first,second):
	result = f(first,second)
	print('f('+displayNum(first)+','+displayNum(second)+') = ' + str(result) + ' (' + str(first * first + second * second + 11) + ')')
	return result
	
iv = 0b1111
block1 = 0b1011
block2 = 0b1001
block3 = 0b0100
block4 = 0b1010
ipad = 0b1001
opad = 0b0110
key = 0b1010
block0_0 = ipad ^ key
block0_1 = opad ^ key

result = printStep(iv,block0_0)
result = printStep(result,block1)
result = printStep(result,block2)
result = printStep(result,block3)
result = printStep(result,block4)