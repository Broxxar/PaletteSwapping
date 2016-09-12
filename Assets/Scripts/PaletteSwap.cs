using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PaletteSwap : MonoBehaviour
{
	public Color In0;
	public Color In1;
	public Color In2;
	public Color In3;
	public Color Out0;
	public Color Out1;
	public Color Out2;
	public Color Out3;

	Material _mat;

	void OnEnable()
	{
		Shader shader = Shader.Find("Hidden/PaletteSwapNaive");
		if (_mat == null)
			_mat = new Material(shader);
    }

	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		_mat.SetColor("_In0", In0);
		_mat.SetColor("_Out0", Out0);
		_mat.SetColor("_In1", In1);
		_mat.SetColor("_Out1", Out1);
		_mat.SetColor("_In2", In2);
		_mat.SetColor("_Out2", Out2);
		_mat.SetColor("_In3", In3);
		_mat.SetColor("_Out3", Out3);

		Graphics.Blit(src, dst,  _mat);
	}


}
