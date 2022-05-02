

/** TestScene.HexToDec
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE) && false
namespace TestScene.HexToDec
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : BlueBack.VariableDigit.InspectorViewer_MonoBehaviour
	{
		/** hex
		*/
		public System.Collections.Generic.LinkedList<int> hex;

		/** result
		*/
		public BlueBack.VariableDigit.DecValue result;

		/** [BlueBack.VariableDigit.InspectorViewer_MonoBehaviour]表示物の取得。
		*/
		#if(UNITY_EDITOR)
		public override BlueBack.VariableDigit.DecValue GetDecValue()
		{
			return this.result;
		}
		#endif

		/** Start
		*/
		private void Start()
		{
			//「F.ABCDEF」１６進数。
			{
				this.hex = new System.Collections.Generic.LinkedList<int>();
				this.hex.AddLast(15);
				this.hex.AddLast(10);
				this.hex.AddLast(11);
				this.hex.AddLast(12);
				this.hex.AddLast(13);
				this.hex.AddLast(14);
				this.hex.AddLast(15);
			}

			//CoroutineMain
			this.StartCoroutine(this.CoroutineMain());
		}

		/** CoroutineMain
		*/
		private System.Collections.IEnumerator CoroutineMain()
		{
			this.result = BlueBack.VariableDigit.BusyConvert.ToDecValue(0);

			BlueBack.VariableDigit.DecValue t_bias = BlueBack.VariableDigit.BusyConvert.ToDecValue(1);
			BlueBack.VariableDigit.DecValue t_16 = BlueBack.VariableDigit.BusyConvert.ToDecValue(16);

			BlueBack.VariableDigit.DecValue t_calc_bias_inv = BlueBack.VariableDigit.BusyConvert.ToDecValue(1);
			BlueBack.VariableDigit.DecValue t_calc_16_inv = BlueBack.VariableDigit.BusyConvert.ToDecValue("0.0625");

			System.Collections.Generic.LinkedListNode<int> t_hex_node = this.hex.Last;
			do{
				BlueBack.VariableDigit.DecValue t_add = BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue(t_hex_node.Value),t_bias);
				
				this.result = BlueBack.VariableDigit.BusyAddition.Addition(this.result,t_add);

				t_hex_node = t_hex_node.Previous;
				if(t_hex_node != null){
					yield return null;
					t_bias = BlueBack.VariableDigit.BusyMultiply.Multiply(t_bias,t_16);
					t_calc_bias_inv = BlueBack.VariableDigit.BusyMultiply.Multiply(t_calc_bias_inv,t_calc_16_inv);
				}else{
					break;
				}
				
			}while(true);

			this.result = BlueBack.VariableDigit.BusyMultiply.Multiply(this.result,t_calc_bias_inv);

			{
				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
				BlueBack.VariableDigit.BusyConvert.ToStringBuilder(this.result,t_stringbuilder);
				UnityEngine.Debug.Log(t_stringbuilder.ToString());
			}

			yield break;
		}
	}
}
#endif

