

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief １００進数。可変桁。浮動小数点。
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** DecValue
	*/
	public sealed class DecValue
	{
		/** 符号。
		*/
		public sbyte sign;

		/** 指数。
		*/
		public long exponent;

		/** 仮数。

			 [AA,BB,CC,*,*,*] : AA.BBCC***

			 数値 : sign * pow(100,exponent) * AA.BBCC***

		*/
		public System.Collections.Generic.LinkedList<int> list;

		/** zero
		*/
		public static readonly DecValue zero = new DecValue();

		/** constructor
		*/
		public DecValue()
		{
			//sign
			this.sign = 1;

			//exponent
			this.exponent = 0;

			//list
			this.list = new System.Collections.Generic.LinkedList<int>();
			this.list.AddLast(0);
		}

		/** constructor
		*/
		public DecValue(sbyte a_sign,long a_exponent,int[] a_list)
		{
			#if(DEF_BLUEBACK_VARIABLEDIGIT_ASSERT)
			DebugTool.Assert((a_sign == 1)||(a_sign == -1),"error:sign");
			#endif

			//sign
			this.sign = a_sign;

			//exponent
			this.exponent = a_exponent;

			//list
			this.list = new System.Collections.Generic.LinkedList<int>(a_list);
		}

		/** constructor
		*/
		public DecValue(sbyte a_sign,long a_exponent,System.Collections.Generic.LinkedList<int> a_list)
		{
			#if(DEF_BLUEBACK_VARIABLEDIGIT_ASSERT)
			DebugTool.Assert((a_sign == 1)||(a_sign == -1),"error:sign");
			#endif

			//sign
			this.sign = a_sign;

			//exponent
			this.exponent = a_exponent;

			//list
			this.list = a_list;
		}
	}
}

