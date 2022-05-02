

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Busy処理。
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** BusyPow
	*/
	public static class BusyPow
	{
		/** Pow
		*/
		public static DecValue Pow(DecValue a_value,ulong a_count)
		{
			DecValue t_value = a_value;
			DecValue t_result = DecValue.one;
			ulong t_count = a_count;

			while(t_count > 0){
				if((t_count & 1) != 0){
					t_result = BusyMultiply.Multiply(t_result,t_value);
				}
				t_value = BusyMultiply.Multiply(t_value,t_value);
				t_count >>= 1;
			}
			return t_result;
		}
	}
}

