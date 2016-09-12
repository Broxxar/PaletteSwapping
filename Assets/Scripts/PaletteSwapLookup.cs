using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PaletteSwapLookup : MonoBehaviour
{
	public Texture LookupTexture;

	Material _mat;

	void OnEnable()
	{
		Shader shader = Shader.Find("Hidden/PaletteSwapLookup");
		if (_mat == null)
			_mat = new Material(shader);
    }

	void OnDisable()
	{
		if (_mat != null)
			DestroyImmediate(_mat);
	}

	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		_mat.SetTexture("_PaletteTex", LookupTexture);
		Graphics.Blit(src, dst,  _mat);
	}


}
