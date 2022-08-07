

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
		public System.Collections.Generic.LinkedList<int> mantissa;

		/** Value
		*/
		private enum Value_1{ID=0};
		private enum Value_2{ID=0};
		private enum Value_2_Inverse{ID=0};
		private enum Value_4{ID=0};
		private enum Value_4_Inverse{ID=0};
		private enum Value_16{ID=0};
		private enum Value_16_Inverse{ID=0};

		/** value
		*/
		public static readonly DecValue value_0 = new DecValue();
		public static readonly DecValue value_1 = new DecValue(Value_1.ID);
		public static readonly DecValue value_2 = new DecValue(Value_2.ID);
		public static readonly DecValue value_2_inverse = new DecValue(Value_2_Inverse.ID);
		public static readonly DecValue value_4 = new DecValue(Value_4.ID);
		public static readonly DecValue value_4_inverse = new DecValue(Value_4_Inverse.ID);
		public static readonly DecValue value_16 = new DecValue(Value_16.ID);
		public static readonly DecValue value_16_inverse = new DecValue(Value_16_Inverse.ID);

		/** constructor
		*/
		public DecValue()
		{
			//sign
			this.sign = 1;

			//exponent
			this.exponent = 0;

			//mantissa
			this.mantissa = new System.Collections.Generic.LinkedList<int>();
			this.mantissa.AddLast(0);
		}

		/** constructor
		*/
		public DecValue(DecValue a_value)
		{
			//sign
			this.sign = a_value.sign;

			//exponent
			this.exponent = a_value.exponent;

			//mantissa
			this.mantissa = new System.Collections.Generic.LinkedList<int>(a_value.mantissa);
		}

		/** constructor
		*/
		private DecValue(Value_1 a_value)
		{
			//sign
			this.sign = 1;

			//exponent
			this.exponent = 0;

			//mantissa
			this.mantissa = new System.Collections.Generic.LinkedList<int>();
			this.mantissa.AddLast(1);
		}

		/** constructor
		*/
		private DecValue(Value_2 a_value)
		{
			//sign
			this.sign = 1;

			//exponent
			this.exponent = 0;

			//mantissa
			this.mantissa = new System.Collections.Generic.LinkedList<int>();
			this.mantissa.AddLast(2);
		}

		/** constructor
		*/
		private DecValue(Value_2_Inverse a_value)
		{
			//sign
			this.sign = 1;

			//exponent
			this.exponent = -1;

			//mantissa
			this.mantissa = new System.Collections.Generic.LinkedList<int>();
			this.mantissa.AddLast(50);
		}

		/** constructor
		*/
		private DecValue(Value_4 a_value)
		{
			//sign
			this.sign = 1;

			//exponent
			this.exponent = 0;

			//mantissa
			this.mantissa = new System.Collections.Generic.LinkedList<int>();
			this.mantissa.AddLast(4);
		}

		/** constructor
		*/
		private DecValue(Value_4_Inverse a_value)
		{
			//sign
			this.sign = 1;

			//exponent
			this.exponent = -1;

			//mantissa
			this.mantissa = new System.Collections.Generic.LinkedList<int>();
			this.mantissa.AddLast(25);
		}

		/** constructor
		*/
		private DecValue(Value_16 a_value)
		{
			//sign
			this.sign = 1;

			//exponent
			this.exponent = 0;

			//mantissa
			this.mantissa = new System.Collections.Generic.LinkedList<int>();
			this.mantissa.AddLast(16);
		}

		/** constructor
		*/
		private DecValue(Value_16_Inverse a_value)
		{
			//sign
			this.sign = 1;

			//exponent
			this.exponent = -1;

			//mantissa
			this.mantissa = new System.Collections.Generic.LinkedList<int>();
			this.mantissa.AddLast(6);
			this.mantissa.AddLast(25);
		}

		/** constructor
		*/
		public DecValue(sbyte a_sign,long a_exponent,int[] a_list)
		{
			#if(DEF_BLUEBACK_ASSERT)
			DebugTool.Assert((a_sign == 1)||(a_sign == -1),"error:sign");
			#endif

			//sign
			this.sign = a_sign;

			//exponent
			this.exponent = a_exponent;

			//mantissa
			this.mantissa = new System.Collections.Generic.LinkedList<int>(a_list);
		}

		/** constructor
		*/
		public DecValue(sbyte a_sign,long a_exponent,System.Collections.Generic.LinkedList<int> a_list)
		{
			#if(DEF_BLUEBACK_ASSERT)
			DebugTool.Assert((a_sign == 1)||(a_sign == -1),"error:sign");
			#endif

			//sign
			this.sign = a_sign;

			//exponent
			this.exponent = a_exponent;

			//mantissa
			this.mantissa = a_list;
		}

		/** CutMantissa
		*/
		public void CutMantissa(int a_limit)
		{
			while(this.mantissa.Count > a_limit){
				this.mantissa.RemoveLast();
			}
		}
	}
}

