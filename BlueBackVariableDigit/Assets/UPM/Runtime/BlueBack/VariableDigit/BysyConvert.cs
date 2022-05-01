

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
	public class BusyConvert
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
			long t_value = a_value * t_sign;

			//exponent
			long t_exponent = ((t_value == 0) ? (0) : (long)System.Math.Log(t_value,100));

			//list
			System.Collections.Generic.LinkedList<int> t_list = new System.Collections.Generic.LinkedList<int>();
			if(t_value == 0){
				t_list.AddFirst(0);
			}else{
				bool t_first = true;

				while(t_value > 0){
					long t_mod = t_value % 100;

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
			int t_index = a_value.IndexOf('.');

			UnityEngine.Debug.Log(t_index.ToString());


			return new DecValue();
		}

		/** ToDecValue
		*/
		public static DecValue ToDecValue(double a_value)
		{
			//sign
			sbyte t_sign = (a_value >= 0) ? ((sbyte)1) : ((sbyte)-1);

			ulong t_value_i;
			ulong t_value_f;
			{
				double t_value_unsigned = a_value * t_sign;

				//整数部。
				t_value_i = (ulong)System.Math.Truncate(t_value_unsigned);

				//少数部 * pow(100,3)
				t_value_f = (ulong)System.Math.Truncate((t_value_unsigned - t_value_i) * (1000000));
			}

			//exponent
			long t_exponent;

			//list
			System.Collections.Generic.LinkedList<int> t_list = new System.Collections.Generic.LinkedList<int>();

			if(t_value_f == 0){
				if(t_value_i == 0){
					//ゼロ。

					//exponent
					t_exponent = 0;

					//list
					t_list = new System.Collections.Generic.LinkedList<int>();
					t_list.AddFirst(0);

				}else{
					//整数あり。少数なし。

					//exponent
					t_exponent = (long)System.Math.Log(t_value_i,100);

					//list
					t_list = new System.Collections.Generic.LinkedList<int>();

					//AddFirst
					{
						bool t_first = true;

						while(t_value_i > 0){
							ulong t_mod = t_value_i % 100;

							if(t_first == true){
								if(t_mod == 0){
									t_value_i /= 100;
									continue;
								}
								t_first = false;
							}

							t_list.AddFirst((int)t_mod);
							t_value_i /= 100;
						}
					}
				}
			}else if(t_value_i == 0){
				//整数なし。少数あり。

				//少数部 * pow(100,3)
				//exponent
				t_exponent = (long)System.Math.Log(t_value_f,100) - 3;

				//list
				t_list = new System.Collections.Generic.LinkedList<int>();

				//AddFirst
				{
					bool t_first = true;

					while(t_value_f > 0){
						ulong t_mod = t_value_f % 100;

						if(t_first == true){
							if(t_mod == 0){
								t_value_f /= 100;
								continue;
							}
							t_first = false;
						}

						t_list.AddFirst((int)t_mod);
						t_value_f /= 100;
					}
				}
			}else{
				//整数あり。少数あり。

				//exponent
				t_exponent = (long)System.Math.Log(t_value_i,100);

				//list
				t_list = new System.Collections.Generic.LinkedList<int>();

				//少数。
				{
					bool t_first = true;

					//少数部 * pow(100,3)
					int t_digit = 3;

					while(t_value_f > 0){
						ulong t_mod = t_value_f % 100;

						if(t_first == true){
							if(t_mod == 0){
								t_value_f /= 100;
								t_digit--;
								continue;
							}
							t_first = false;
						}

						t_list.AddFirst((int)t_mod);
						t_value_f /= 100;
					}

					while(t_list.Count < t_digit){
						t_list.AddFirst(0);
					}
				}

				//整数。
				{
					while(t_value_i > 0){
						ulong t_mod = t_value_i % 100;
						t_list.AddFirst((int)t_mod);
						t_value_i /= 100;
					}
				}
			}

			return new DecValue(t_sign,t_exponent,t_list);
		}
	}
}

