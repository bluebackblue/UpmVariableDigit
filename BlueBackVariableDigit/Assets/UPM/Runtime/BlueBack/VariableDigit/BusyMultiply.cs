

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Busy処理。
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** BusyMultiply
	*/
	public static class BusyMultiply
	{
		/** Multiply
		*/
		public static DecValue Multiply(DecValue a_1,DecValue a_2)
		{
			if(a_1.list.Count == 1){
				if(a_1.list.First.Value == 0){
					System.Collections.Generic.LinkedList<int> t_result = new System.Collections.Generic.LinkedList<int>();
					t_result.AddLast(0);
					return new DecValue(1,0,t_result);
				}
			}else if(a_2.list.Count == 1){
				if(a_2.list.First.Value == 0){
					System.Collections.Generic.LinkedList<int> t_result = new System.Collections.Generic.LinkedList<int>();
					t_result.AddLast(0);
					return new DecValue(1,0,t_result);
				}
			}

			{
				System.Collections.Generic.LinkedList<int> t_result = new System.Collections.Generic.LinkedList<int>();
				{
					int ii_max = a_1.list.Count + a_2.list.Count;
					for(int ii=0;ii<ii_max;ii++){
						t_result.AddLast(0);
					}
				}
			
				System.Collections.Generic.LinkedListNode<int> t_result_node_base = t_result.Last;

				System.Collections.Generic.LinkedListNode<int> t_node_2 = a_2.list.Last;
				while(t_node_2 != null){
					//乗算。
					{
						System.Collections.Generic.LinkedListNode<int> t_result_node = t_result_node_base;
						System.Collections.Generic.LinkedListNode<int> t_node_1 = a_1.list.Last;
						while(t_node_1 != null){
							t_result_node.Value += t_node_1.Value * t_node_2.Value;
							t_node_1 = t_node_1.Previous;
							t_result_node = t_result_node.Previous;
						}

						t_node_2 = t_node_2.Previous;
						t_result_node_base = t_result_node_base.Previous;
					}

					//桁上げ。
					{
						System.Collections.Generic.LinkedListNode<int> t_node_normalize = t_result.Last;

						while(t_node_normalize != null){
							System.Collections.Generic.LinkedListNode<int> t_node_prev = t_node_normalize.Previous;
							int t_temp = t_node_normalize.Value;
							if(t_temp >= 100){
								t_node_normalize.Value = t_temp % 100;
								t_node_prev.Value += (t_temp / 100);
							}
							t_node_normalize = t_node_prev;
						}
					}
				}

				while((t_result.Count > 1)&&(t_result.Last.Value == 0)){
					t_result.RemoveLast();
				}

				if(t_result.First.Value == 0){
					t_result.RemoveFirst();
					return new DecValue((sbyte)(a_1.sign * a_2.sign),a_1.exponent + a_2.exponent,t_result);
				}else{
					return new DecValue((sbyte)(a_1.sign * a_2.sign),a_1.exponent + a_2.exponent + 1,t_result);
				}
			}
		}
	}
}

