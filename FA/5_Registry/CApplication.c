#include <stdio.h>

int main() {
	char PASSWORD[] = "ABCDEF1234";
	printf("Enter password\n");
	char userPrompt[10];
	gets(userPrompt);
	char secretText[] = "MIC0378 Secret text\n";
	if (strcmp(userPrompt, PASSWORD) == 0)
	{
		printf(secretText);
	}
	else
	{
		printf("Wrong password\n");
	}
	system("pause");
	return 0;
}