

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Busy処理。
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** BusyDivision
	*/
	public static class BusyDivision
	{
		/** Compare
		*/
		private static int Compare(System.Collections.Generic.LinkedList<int> a_1,System.Collections.Generic.LinkedList<int> a_2)
		{
			System.Collections.Generic.LinkedListNode<int> t_node_1 = a_1.First;
			System.Collections.Generic.LinkedListNode<int> t_node_2 = a_2.First;

			if(a_1.Count < a_2.Count){
				return -1;
			}else if(a_1.Count > a_2.Count){
				return 1;
			}else{
				System.Collections.Generic.LinkedListNode<int> t_node_m = a_1.First;
				System.Collections.Generic.LinkedListNode<int> t_node_d = a_2.First;
				while(t_node_m != null){
					if(t_node_m.Value < t_node_d.Value){
						return -1;
					}else if(t_node_m.Value > t_node_d.Value){
						return 1;
					}
					t_node_m = t_node_m.Next;
					t_node_d = t_node_d.Next;
				}

				return 0;
			}
		}

		/** DivisionWithLimit
		*/
		public static DecValue DivisionWithLimit(DecValue a_1,DecValue a_2,int a_limit)
		{
			//div
			System.Collections.Generic.LinkedList<int> t_div = a_2.mantissa;

			//mod
			System.Collections.Generic.LinkedList<int> t_mod = new System.Collections.Generic.LinkedList<int>();
			System.Collections.Generic.LinkedListNode<int> t_a1_node = a_1.mantissa.First;
			t_mod.AddLast(t_a1_node.Value);
			t_a1_node = t_a1_node.Next;

			//result
			System.Collections.Generic.LinkedList<int> t_result = new System.Collections.Generic.LinkedList<int>();
			t_result.AddLast(0);

			int t_limit = a_limit;

			do{
				int t_sub = Compare(t_mod,t_div);
				if(t_sub < 0){
					//足りない。

					t_limit--;
					if(t_limit < 0){
						break;
					}

					if(t_a1_node != null){
						t_mod.AddLast(t_a1_node.Value);
						t_a1_node = t_a1_node.Next;
					}else{
						if(t_mod.Count == 0){
							//割りけれた。
							break;
						}else{
							t_mod.AddLast(0);
						}
					}

					//result
					t_result.AddLast(0);
				}else if(t_sub >= 0){
					//引く。

					{
						System.Collections.Generic.LinkedListNode<int> t_node_m = t_mod.Last;
						System.Collections.Generic.LinkedListNode<int> t_node_d = t_div.Last;
						while(t_node_d != null){
							int t_value_m = t_node_m.Value;
							t_value_m -= t_node_d.Value;
							if(t_value_m < 0){
								t_value_m += 100;
								t_node_m.Previous.Value--;
							}
							t_node_m.Value = t_value_m;

							t_node_m = t_node_m.Previous;
							t_node_d = t_node_d.Previous;
						}

						t_result.Last.Value++;
					}

					//正規化。
					{
						while((t_mod.First != null)&&(t_mod.First.Value == 0)){
							t_mod.RemoveFirst();
						}
					}
				}
			}while(true);

			//sign
			sbyte t_sign = (sbyte)(a_1.sign * a_2.sign);

			//exponent
			long t_exponent = a_1.exponent - a_2.exponent;

			return new DecValue(t_sign,t_exponent,t_result);
		}
	}
}

