#include "CheckParenthesesParity.h"

namespace ADSLibrary
{
	namespace Algorithms
	{
		namespace CheckParenthesesParity
		{
			bool CheckParenthesesParity1(string Expr)
			{
				Stack S;
				Init(S);
				for (size_t i = 0; i < Expr.length(); i++)
				{
					switch (Expr[i])
					{
					case '(':
					case '[':
					case '{':
						Push(S, Expr[i]);
						break;
					case ')':
						if (!IsEmpty(S))
						{
							char ch = Pop(S);
							if (ch != '(')
							{
								return false;
							}
						}
						else
						{
							return false;
						}
						break;
					case ']':
						if (!IsEmpty(S))
						{
							char ch = Pop(S);
							if (ch != '[')
							{
								return false;
							}
						}
						else
						{
							return false;
						}
						break;
					case '}':
						if (!IsEmpty(S))
						{
							char ch = Pop(S);
							if (ch != '{')
							{
								return false;
							}
						}
						else
						{
							return false;
						}
						break;
					}
				}
				return IsEmpty(S);
			}
			
			bool CheckParenthesesParity2(string Expr)
			{
				Stack S;
				Init(S);
				for(size_t i = 0; i < Expr.length(); i++)
				{
					switch (Expr[i])
					{
					case '(':
						Push(S, ')');
						break;
					case '[':
						Push(S, ']');
						break;
					case '{':
						Push(S, '}');
						break;
					case ')':
					case ']':
					case '}':
						if (!IsEmpty(S))
						{
							char ch = Pop(S);
							if (ch != Expr[i])
							{
								return false;
							}
						}
						else
						{
							return false;
						}
						break;
					}
				}
				return IsEmpty(S);
			}
		}
	}
}
