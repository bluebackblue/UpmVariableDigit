

/** BlueBack.VariableDigit.Samples.Convert_HexToDec
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.Convert_HexToDec
{
	/** Main_MonoBehaviour
	*/
	public sealed class Main_MonoBehaviour : InspectorViewer_MonoBehaviour
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
			this.editor_view_list = this.decvalue;
			#endif

			//CoroutineMain
			this.StartCoroutine(this.CoroutineMain());
		}

		/** CoroutineMain
		*/
		private System.Collections.IEnumerator CoroutineMain()
		{
			//「F.ABCDEF」１６進数。
			//「15.671111047267913818359375」１０進数。
			System.Collections.Generic.LinkedList<int> t_hexvalue = new System.Collections.Generic.LinkedList<int>();
			t_hexvalue.AddLast(0xF);
			t_hexvalue.AddLast(0xA);
			t_hexvalue.AddLast(0xB);
			t_hexvalue.AddLast(0xC);
			t_hexvalue.AddLast(0xD);
			t_hexvalue.AddLast(0xE);
			t_hexvalue.AddLast(0xF);

			DecValue t_digitscale = DecValue.value_1;
			DecValue t_result = DecValue.value_0;

			System.Collections.Generic.LinkedListNode<int> t_hex_node = t_hexvalue.Last;

			do{
				//t_dec_add = H(n) * digitscale
				DecValue t_dec_add = BusyMultiply.Multiply(BusyConvert.ToDecValue(t_hex_node.Value),t_digitscale);

				//result += t_dec_add
				t_result = BusyAddition.Addition(t_result,t_dec_add);

				t_hex_node = t_hex_node.Previous;
				if(t_hex_node != null){
					t_digitscale = BusyMultiply.Multiply(t_digitscale,DecValue.value_16);
				}else{
					break;
				}

				{
					this.decvalue[0] = t_result;
					yield return null;
				}
			}while(true);

			DecValue t_calc_bias_inv = BusyDivision.Division(DecValue.value_1,t_digitscale,1000);
			t_result = BusyMultiply.Multiply(t_result,t_calc_bias_inv);

			{
				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
				BusyConvert.AddToStringBuilder(t_result,t_stringbuilder,1000);
				UnityEngine.Debug.Log(string.Format("{0}",t_stringbuilder));
			}

			{
				this.decvalue[0] = t_result;
				yield return null;
			}

			yield break;
		}
	}
}
#endif

