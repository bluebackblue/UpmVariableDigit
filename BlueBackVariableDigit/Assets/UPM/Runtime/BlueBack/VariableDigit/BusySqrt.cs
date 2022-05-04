

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Busy処理。
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** BusySqrt
	*/
	public static class BusySqrt
	{
		/** Sqrt

			NewtonRaphsonMethod

		*/
		public static DecValue Sqrt(DecValue a_value,int a_cut_mantissa,int a_limit_loop)
		{
			//ゼロ。
			{
				if((a_value.mantissa.Count == 0)&&(a_value.mantissa.First.Value == 0)){
					return DecValue.value_0;
				}
			}

			//初期値。
			BlueBack.VariableDigit.DecValue t_result = BlueBack.VariableDigit.BusyMultiply.Multiply(a_value,DecValue.value_2_inverse);

			//half_target = target * 0.5
			BlueBack.VariableDigit.DecValue t_half_target = BlueBack.VariableDigit.BusyMultiply.Multiply(a_value,DecValue.value_2_inverse);

			for(int ii=0;ii<a_limit_loop;ii++){
				//xn_half = X(n) * 0.5
				BlueBack.VariableDigit.DecValue t_xn_half = BlueBack.VariableDigit.BusyMultiply.Multiply(t_result,DecValue.value_2_inverse);

				//result
				t_result.CutMantissa(a_cut_mantissa);

				//xn_inv = 1 / X(n)
				BlueBack.VariableDigit.DecValue t_xn_inv = BlueBack.VariableDigit.BusyDivision.Division(DecValue.value_1,t_result,t_result.mantissa.Count * 2);

				//xn_inv_half_target = xn_inv * half_target
				BlueBack.VariableDigit.DecValue t_xn_inv_half_target = BlueBack.VariableDigit.BusyMultiply.Multiply(t_xn_inv,t_half_target);

				//X(n+1)
				t_result = BlueBack.VariableDigit.BusyAddition.Addition(t_xn_half,t_xn_inv_half_target);
			}

			return t_result;
		}
	}
}

