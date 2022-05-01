

/** TestScene.HexToDec
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
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
			BlueBack.VariableDigit.DecValue t_exponent = BlueBack.VariableDigit.BusyConvert.ToDecValue(1);
			this.result = BlueBack.VariableDigit.BusyConvert.ToDecValue(0);

			//0.0625
			BlueBack.VariableDigit.DecValue t_inverse_16 = new BlueBack.VariableDigit.DecValue(1,-1,new int[]{6,25});

			System.Collections.Generic.LinkedListNode<int> t_hex_node = this.hex.First;
			while(t_hex_node != null){
				BlueBack.VariableDigit.DecValue t_add = BlueBack.VariableDigit.BusyMultiply.Multiply(t_exponent,BlueBack.VariableDigit.BusyConvert.ToDecValue(t_hex_node.Value));
				this.result = BlueBack.VariableDigit.BusyAddition.Addition(this.result,t_add);
				t_exponent = BlueBack.VariableDigit.BusyMultiply.Multiply(t_exponent,t_inverse_16);
				t_hex_node = t_hex_node.Next;
				yield return null;
			}

			UnityEngine.Debug.Log(string.Format("{0}",BlueBack.VariableDigit.BusyConvert.ToDouble(this.result,1000)));

			yield break;
		}
	}
}
#endif

