

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Busy処理。
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** BusyCompare
	*/
	public static class BusyCompare
	{
		/** Compare

			return ＞ 0		: a_1 ＞ a_2
			return ＜ 0		: a_1 ＜ a_2
			return == 0		: a_1 == a_2

		*/
		public static int Compare(DecValue a_1,DecValue a_2)
		{
			//ゼロ。
			if(a_1.mantissa.First.Value == 0){
				if(a_2.mantissa.First.Value == 0){
					return 0;
				}else{
					return -1;
				}
			}else if(a_2.mantissa.First.Value == 0){
				return 1;
			}

			//符号。
			if(a_1.sign > a_2.sign){
				return 1;
			}else if(a_1.sign < a_2.sign){
				return -1;
			}

			sbyte t_sign = a_1.sign;

			if(a_1.exponent > a_2.exponent){
				return t_sign;
			}else if(a_1.exponent < a_2.exponent){
				return -t_sign;
			}
			
			System.Collections.Generic.LinkedListNode<int> t_node_1 = a_1.mantissa.First;
			System.Collections.Generic.LinkedListNode<int> t_node_2 = a_2.mantissa.First;

			do{
				int t_1_value = (t_node_1 != null) ? (t_node_1.Value) : 0;
				int t_2_value = (t_node_2 != null) ? (t_node_2.Value) : 0;

				if(t_1_value > t_2_value){
					return t_sign;
				}else if(t_1_value < t_2_value){
					return -t_sign;
				}

				if(t_node_1 != null){
					t_node_1 = t_node_1.Next;
				}

				if(t_node_2 != null){
					t_node_2 = t_node_2.Next;
				}

			}while((t_node_1 != null)||(t_node_2 != null));

			return 0;
		}
	}
}

