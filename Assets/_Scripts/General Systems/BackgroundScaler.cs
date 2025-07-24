using UnityEngine;

namespace CannonGame
{
    public class BackgroundScaler : MonoBehaviour
    {
        [SerializeField] SpriteRenderer SR;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            UpdateScale();
        }

        void UpdateScale()
        {
			int screenSizeX = Screen.width;
			int screenSizeY = Screen.height;

            float spriteHeight = SR.sprite.rect.height;
			float spriteWidth = SR.sprite.rect.width;

            float sizeX = screenSizeX / spriteWidth;
			float sizeY = screenSizeY / spriteHeight;

            if(sizeX >= sizeY)
            {
				transform.localScale = new Vector3(sizeX, sizeX, 1);
                Material mat = SR.material;
                mat.SetFloat("_Scale", sizeX);
                SR.material = mat;

			}
            else
            {
				transform.localScale = new Vector3(sizeY, sizeY, 1);
				Material mat = SR.material;
				mat.SetFloat("_Scale", sizeY);
				SR.material = mat;
			}


		}
    }
}
