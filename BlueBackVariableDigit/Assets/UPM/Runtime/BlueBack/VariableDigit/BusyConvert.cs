

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Busy処理。
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** BusyConvert
	*/
	public static class BusyConvert
	{
		/** ToDouble
		*/
		public static double ToDouble(DecValue a_value,int a_limit)
		{
			double t_result = 0d;

			{
				int t_exponent = 0;

				System.Collections.Generic.LinkedListNode<int> t_node = a_value.list.First;
				for(int ii=0;((ii<a_limit)&&(t_node != null));ii++){
					t_result += t_node.Value * System.Math.Pow(100,t_exponent);
					t_exponent--;
					t_node = t_node.Next;
				}
			}

			t_result *= a_value.sign * System.Math.Pow(100,a_value.exponent);

			return t_result;
		}

		/** ToDecValue
		*/
		public static DecValue ToDecValue(long a_value)
		{
			//sign
			sbyte t_sign = (a_value >= 0) ? ((sbyte)1) : ((sbyte)-1);

			//value
			ulong t_value = (ulong)(a_value * t_sign);

			//exponent
			long t_exponent = ((t_value == 0) ? (0) : (long)System.Math.Log(t_value,100));

			//list
			System.Collections.Generic.LinkedList<int> t_list = new System.Collections.Generic.LinkedList<int>();
			if(t_value == 0){
				t_list.AddFirst(0);
			}else{
				bool t_first = true;

				while(t_value > 0){
					ulong t_mod = t_value % 100;

					if(t_first == true){
						if(t_mod == 0){
							t_value /= 100;
							continue;
						}
						t_first = false;
					}

					t_list.AddFirst((int)t_mod);
					t_value /= 100;
				}
			}

			return new DecValue(t_sign,t_exponent,t_list);
		}

		/** ToDecValue
		*/
		public static DecValue ToDecValue(sbyte a_sign,ulong a_value)
		{
			//sign
			sbyte t_sign = a_sign;

			//value
			ulong t_value = a_value;

			//exponent
			long t_exponent = ((t_value == 0) ? (0) : (long)System.Math.Log(t_value,100));

			//list
			System.Collections.Generic.LinkedList<int> t_list = new System.Collections.Generic.LinkedList<int>();
			if(t_value == 0){
				t_list.AddFirst(0);
			}else{
				bool t_first = true;

				while(t_value > 0){
					ulong t_mod = t_value % 100;

					if(t_first == true){
						if(t_mod == 0){
							t_value /= 100;
							continue;
						}
						t_first = false;
					}

					t_list.AddFirst((int)t_mod);
					t_value /= 100;
				}
			}

			return new DecValue(t_sign,t_exponent,t_list);
		}

		/** ToDecValue
		*/
		public static DecValue ToDecValue(string a_value)
		{
			int t_index_base = a_value.IndexOf('.');

			//sign
			sbyte t_sign;

			int t_index_i_min;
			{
				switch(a_value[0]){
				case '-':
					{
						t_index_i_min = 1;
						t_sign = -1;
					}break;
				case '+':
					{
						t_index_i_min = 1;
						t_sign = 1;
					}break;
				default:
					{
						t_index_i_min = 0;
						t_sign = 1;
					}break;
				}
			}

			int t_index_i_max;
			int t_index_f_min;
			int t_index_f_max;
			if(t_index_base >= 0){
				//少数あり。
				t_index_i_max = t_index_base - 1;
				t_index_f_min = t_index_base + 1;
				t_index_f_max = a_value.Length - 1;
			}else{
				//整数のみ。
				t_index_i_max = a_value.Length - 1;
				t_index_f_min = -1;
				t_index_f_max = -1;
			}


			//exponent
			long t_exponent;
			{
				int t_i_count = t_index_i_max - t_index_i_min + 1;
				if(t_i_count <= 2){
					t_exponent = 0;
				}else{
					t_exponent = (long)((t_i_count - 1) / 2);
				}
			}

			//result
			System.Collections.Generic.LinkedList<int> t_result = new System.Collections.Generic.LinkedList<int>();

			//少数。
			if(t_index_f_min >= 0){
				int t_index = t_index_f_min;

				do{
					int t_value_10;
					int t_value_01;

					if(t_index <= t_index_f_max){
						t_value_10 = a_value[t_index] - '0';
					}else{
						t_value_10 = 0;
						break;
					}

					t_index++;

					if(t_index <= t_index_f_max){
						t_value_01 = a_value[t_index] - '0';
					}else{
						t_value_01 = 0;
					}

					t_index++;

					t_result.AddLast(t_value_10 * 10 + t_value_01);
				}while(true);

				//正規化。
				{
					while((t_result.Count > 0)&&(t_result.Last.Value == 0)){
						t_result.RemoveLast();
					}
				}
			}

			//整数。
			{
				int t_index = t_index_i_max;

				do{
					int t_value_10;
					int t_value_01;

					if(t_index >= t_index_i_min){
						t_value_01 = a_value[t_index] - '0';
					}else{
						t_value_01 = 0;
						break;
					}

					t_index--;

					if(t_index >= t_index_i_min){
						t_value_10 = a_value[t_index] - '0';
					}else{
						t_value_10 = 0;
					}

					t_index--;

					t_result.AddFirst(t_value_10 * 10 + t_value_01);
				}while(true);

				//正規化。
				{
					while((t_result.Count > 1)&&(t_result.First.Value == 0)){
						t_result.RemoveFirst();
						t_exponent--;
					}
				}
			}

			return new DecValue(t_sign,t_exponent,t_result);
		}

		/** ToDecValue
		*/
		public static DecValue ToDecValue(double a_value)
		{
			ulong t_bit = System.BitConverter.ToUInt64(System.BitConverter.GetBytes(a_value),0);
			
			DecValue t_value = ToDecValue(((t_bit & 0x8000000000000000UL) == 0) ? (sbyte)1 : (sbyte)-1,(t_bit & 0x000FFFFFFFFFFFFFUL) | 0x0010000000000000UL);
			long t_exponent = ((long)((t_bit & 0x7FF0000000000000UL) >> 52)) - 1075;
			DecValue t_pow2exponent = (t_exponent > 0) ? (BusyPow.Pow(DecValue.two,(ulong)t_exponent)) : (BusyPow.Pow(DecValue.half,(ulong)-t_exponent));
			t_value = BusyMultiply.Multiply(t_value,t_pow2exponent);
			return t_value;
		}
	}
}

