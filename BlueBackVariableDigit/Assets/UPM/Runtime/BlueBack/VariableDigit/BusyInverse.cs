

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Busy処理。
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** BusyInverse
	*/
	public static class BusyInverse
	{
		/** Inverse

			NewtonRaphsonMethod

		*/
		public static DecValue Inverse(DecValue a_value,int a_limit_loop,int a_cut_mantissa)
		{
			//初期値。
			DecValue t_result;
			{
				t_result = DecValue.value_1;
				while(true){
					DecValue t_1_delta_m = BusyMultiply.Multiply(a_value,t_result);
					if(t_1_delta_m.exponent >= 0){
						t_result.exponent -= 1 + t_1_delta_m.exponent;
					}else{
						break;
					}
				}
			}

			for(int ii=0;ii<a_limit_loop;ii++){
				DecValue t_1_delta_m = BusyMultiply.Multiply(a_value,t_result);
				DecValue t_1_delta_p = BusySubtraction.Subtraction(DecValue.value_2,t_1_delta_m);
				t_result = BusyMultiply.Multiply(t_result,t_1_delta_p);
				t_result.CutMantissa(a_cut_mantissa);
			}

			return t_result;
		}
	}
}

