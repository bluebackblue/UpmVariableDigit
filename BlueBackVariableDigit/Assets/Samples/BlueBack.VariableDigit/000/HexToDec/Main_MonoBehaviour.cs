

/** BlueBack.VariableDigit.Samples.HexToDec
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.HexToDec
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** decvalue
		*/
		public System.Collections.Generic.List<DecValue> decvalue;

		/** Awake
		*/
		private void Awake()
		{
			this.decvalue = new System.Collections.Generic.List<DecValue>(){null};
		}

		/** Start
		*/
		private void Start()
		{
			#if(UNITY_EDITOR)
			this.gameObject.AddComponent<BlueBack.VariableDigit.InspectorViewer_MonoBehaviour>().decvalue = this.decvalue;
			#endif

			//CoroutineMain
			this.StartCoroutine(this.CoroutineMain());
		}
		
		/** CoroutineMain
		*/
		private System.Collections.IEnumerator CoroutineMain()
		{
			//「F.ABCDEF」１６進数。
			System.Collections.Generic.LinkedList<int> t_hexvalue = new System.Collections.Generic.LinkedList<int>();
			t_hexvalue.AddLast(0xF);
			t_hexvalue.AddLast(0xA);
			t_hexvalue.AddLast(0xB);
			t_hexvalue.AddLast(0xC);
			t_hexvalue.AddLast(0xD);
			t_hexvalue.AddLast(0xE);
			t_hexvalue.AddLast(0xF);

			BlueBack.VariableDigit.DecValue t_bias = BlueBack.VariableDigit.BusyConvert.ToDecValue(1);
			BlueBack.VariableDigit.DecValue t_16 = BlueBack.VariableDigit.BusyConvert.ToDecValue(16);

			BlueBack.VariableDigit.DecValue t_calc_bias_inv = BlueBack.VariableDigit.BusyConvert.ToDecValue(1);
			BlueBack.VariableDigit.DecValue t_calc_16_inv = BlueBack.VariableDigit.BusyConvert.ToDecValue("0.0625");

			DecValue t_decvalue = BlueBack.VariableDigit.BusyConvert.ToDecValue(0);

			System.Collections.Generic.LinkedListNode<int> t_hex_node = t_hexvalue.Last;

			do{
				BlueBack.VariableDigit.DecValue t_add = BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue(t_hex_node.Value),t_bias);
				
				t_decvalue = BlueBack.VariableDigit.BusyAddition.Addition(t_decvalue,t_add);

				t_hex_node = t_hex_node.Previous;
				if(t_hex_node != null){
					t_bias = BlueBack.VariableDigit.BusyMultiply.Multiply(t_bias,t_16);
					t_calc_bias_inv = BlueBack.VariableDigit.BusyMultiply.Multiply(t_calc_bias_inv,t_calc_16_inv);
				}else{
					break;
				}

				{
					this.decvalue[0] = t_decvalue;
					yield return null;
				}
			}while(true);

			t_decvalue = BlueBack.VariableDigit.BusyMultiply.Multiply(t_decvalue,t_calc_bias_inv);

			{
				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
				BlueBack.VariableDigit.BusyConvert.ToStringBuilder(t_decvalue,t_stringbuilder);
				UnityEngine.Debug.Log(t_stringbuilder.ToString());
			}

			{
				this.decvalue[0] = t_decvalue;
				yield return null;
			}

			yield break;
		}
	}
}
#endif

