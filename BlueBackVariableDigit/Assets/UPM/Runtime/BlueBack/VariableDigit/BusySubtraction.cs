

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Busy処理。
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** BusySubtraction
	*/
	public static class BusySubtraction
	{
		/** Subtraction
		*/
		public static DecValue Subtraction(DecValue a_1,DecValue a_2)
		{
			long t_exponent_base = ((a_1.exponent > a_2.exponent) ? (a_1.exponent) : (a_2.exponent));

			//node
			System.Collections.Generic.LinkedListNode<int> t_node_1 = a_1.list.First;
			System.Collections.Generic.LinkedListNode<int> t_node_2 = a_2.list.First;

			//reaults
			System.Collections.Generic.LinkedList<int> t_result = new System.Collections.Generic.LinkedList<int>();
			t_result.AddLast(0);

			//符号。
			sbyte t_sign;
			sbyte t_sign_1 = a_1.sign;
			sbyte t_sign_2 = (sbyte)(-a_2.sign);
			{
				if(t_sign_1 == t_sign_2){
					t_sign = t_sign_1;
					t_sign_1 = 1;
					t_sign_2 = 1;
				}else{
					int t_compare = BusyCompare.Compare(a_1,a_2);
					if(t_compare > 0){
						t_sign = t_sign_1;
						t_sign_1 = 1;
						t_sign_2 = -1;
					}else if(t_compare < 0){
						t_sign = t_sign_2;
						t_sign_1 = -1;
						t_sign_2 = 1;
					}else{
						return new DecValue(1,0,t_result);
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
						t_node_normalize.Value = t_temp % 100;
						t_node_prev.Value += (t_temp / 100);
					}else if(t_temp < 0){
						t_temp *= -1;
						t_node_normalize.Value = 100 - (t_temp % 100);
						t_node_prev.Value += - 1 - (t_temp / 100);
					}
					t_node_normalize = t_node_prev;
				}
			}

			//正規化。
			{
				while((t_result.Count > 0)&&(t_result.First.Value == 0)){
					t_result.RemoveFirst();
					t_exponent_base--;
				}
			}

			return new DecValue(t_sign,t_exponent_base + 1,t_result);
		}
	}
}

