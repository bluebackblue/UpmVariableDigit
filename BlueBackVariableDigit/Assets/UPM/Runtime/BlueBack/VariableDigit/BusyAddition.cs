

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Busy処理。
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** BusyAddition
	*/
	public static class BusyAddition
	{
		/** Inner_Compare
		*/
		private static int Inner_Compare(DecValue a_1,DecValue a_2)
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

			if(a_1.exponent > a_2.exponent){
				return 1;
			}else if(a_1.exponent < a_2.exponent){
				return -1;
			}

			System.Collections.Generic.LinkedListNode<int> t_node_1 = a_1.mantissa.First;
			System.Collections.Generic.LinkedListNode<int> t_node_2 = a_2.mantissa.First;

			do{
				int t_1_value = (t_node_1 != null) ? (t_node_1.Value) : 0;
				int t_2_value = (t_node_2 != null) ? (t_node_2.Value) : 0;

				if(t_1_value > t_2_value){
					return 1;
				}else if(t_1_value < t_2_value){
					return -1;
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

		/** Addition
		*/
		public static DecValue Addition(DecValue a_1,DecValue a_2)
		{
			long t_exponent_base = ((a_1.exponent > a_2.exponent) ? (a_1.exponent) : (a_2.exponent));

			//node
			System.Collections.Generic.LinkedListNode<int> t_node_1 = a_1.mantissa.First;
			System.Collections.Generic.LinkedListNode<int> t_node_2 = a_2.mantissa.First;

			//reaults
			System.Collections.Generic.LinkedList<int> t_result = new System.Collections.Generic.LinkedList<int>();
			t_result.AddLast(0);

			//符号。
			sbyte t_sign;
			sbyte t_sign_1 = a_1.sign;
			sbyte t_sign_2 = a_2.sign;
			{
				if(t_sign_1 == t_sign_2){
					t_sign = t_sign_1;
					t_sign_1 = 1;
					t_sign_2 = 1;
				}else{
					int t_compare = Inner_Compare(a_1,a_2);
					if(t_compare == 0){
						return new DecValue(1,0,t_result);
					}else if(t_compare > 0){
						if(t_sign_1 > 0){
							t_sign = 1;
						}else{
							t_sign = -1;
						}
						t_sign_1 = 1;
						t_sign_2 = -1;		
					}else{
						if(t_sign_2 > 0){
							t_sign = 1;
						}else{
							t_sign = -1;
						}
						t_sign_1 = -1;
						t_sign_2 = 1;
					}
				}
			}

			//加算。
			{
				System.Collections.Generic.LinkedListNode<int> t_result_node = t_result.Last;

				long t_exponent = t_exponent_base;
				do{
					int t_value = 0;

					if((t_exponent <= a_1.exponent)&&(t_node_1 != null)){
						t_value += t_sign_1 * t_node_1.Value;
						t_node_1 = t_node_1.Next;
					}

					if((t_exponent <= a_2.exponent)&&(t_node_2 != null)){
						t_value += t_sign_2 * t_node_2.Value;
						t_node_2 = t_node_2.Next;
					}

					t_result_node = t_result.AddAfter(t_result_node,t_value);

					t_exponent--;
				}while((t_node_1 != null)||(t_node_2 != null));
			}

			//桁上げ、桁下げ。
			{
				System.Collections.Generic.LinkedListNode<int> t_node_normalize = t_result.Last;

				while(t_node_normalize != null){
					System.Collections.Generic.LinkedListNode<int> t_node_prev = t_node_normalize.Previous;
					int t_temp = t_node_normalize.Value;
					if(t_temp >= 100){
						int t_carry = t_temp / 100;
						t_node_normalize.Value = t_temp - t_carry * 100;
						t_node_prev.Value += t_carry;
					}else if(t_temp < 0){
						int t_carry = 1 + ((1 - t_temp) / 100);
						t_node_normalize.Value = 100 * t_carry + t_temp;
						t_node_prev.Value -= t_carry;
					}
					t_node_normalize = t_node_prev;
				}
			}

			//正規化。
			{
				while((t_result.Count > 1)&&(t_result.First.Value == 0)){
					t_result.RemoveFirst();
					t_exponent_base--;
				}

				while((t_result.Count > 1)&&(t_result.Last.Value == 0)){
					t_result.RemoveLast();
				}
			}

			return new DecValue(t_sign,t_exponent_base + 1,t_result);
		}
	}
}

