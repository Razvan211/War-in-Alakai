using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RN.WIA.InputManager
{
    public class MultipleSelection : MonoBehaviour
    {
        private static Texture2D texture;

        public static Texture2D SelectionTexture
        {
            get
            {   //checks if there is any texture
                //if not it creates one of green color
                if (texture == null)
                {
                    texture = new Texture2D(1, 1);
                    texture.SetPixel(0, 0, Color.green);
                    texture.Apply();
                }
                return texture;
            }
        }

        public static void DrawSelectionRectangle(Rect rect, Color color)
        {
            GUI.color = color;
            GUI.DrawTexture(rect, SelectionTexture);
        }

        public static Rect GetSelectionRectangle(Vector3 screenPos1, Vector3 screenPos2)
        {
            //bottom right to top left
            screenPos1.y = Screen.height - screenPos1.y;
            screenPos2.y = Screen.height - screenPos2.y;

            //corners
            Vector3 bottomRight = Vector3.Max(screenPos1, screenPos2);
            Vector3 topLeft = Vector3.Min(screenPos1, screenPos2);

            //draw the rectangle
            return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
        }


        //check if an object is inside the rectangle
        public static Bounds GetBounds(Camera cam, Vector3 screenPos1, Vector3 screenPos2)
        {
            Vector3 pos1 = cam.ScreenToViewportPoint(screenPos1);
            Vector3 pos2 = cam.ScreenToViewportPoint(screenPos2);

            Vector3 min = Vector3.Min(pos1, pos2);
            Vector3 max = Vector3.Max(pos1, pos2);

            min.z = cam.nearClipPlane;
            max.z = cam.farClipPlane;

            Bounds bounds = new Bounds();
            bounds.SetMinMax(min, max);

            return bounds;
        }
    }
}

