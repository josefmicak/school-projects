#include <limits.h>
#include <iostream>
#include <math.h>
#include <bitset>
#include <string>


int Binary2Hex(std::string Binary)
{
	std::bitset<32> set(Binary);
	int hex = set.to_ulong();

	return hex;
}

std::string GetBinary32(float value)
{
	union
	{
		float input;   
		int   output;
	}    data;

	data.input = value;

	std::bitset<sizeof(float) * CHAR_BIT>   bits(data.output);

	std::string mystring = bits.to_string<char,	std::char_traits<char>,	std::allocator<char> >();

	return mystring;
}


int main()
{
	
	std::string str = GetBinary32((float) 15.3);
	std::cout <<  "15.3:" << std::endl;
	std::cout << str << std::endl << std::endl;
	
	
	std::string binary_str(str);
	std::bitset<32> set(binary_str);
	std::cout << std::hex << set.to_ulong() << std::endl;


	getchar();
	return 0;
}