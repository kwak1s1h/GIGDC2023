using UnityEngine;

public class TSmith : MonoBehaviour
{
    [SerializeField] SmeltMaterial material = null;

    [SerializeField] RefiningMachine a, b, c;

    private int i = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            i ++;
            if(i == 1)
                a.Refining(material);
            else if(i == 2)
                b.Refining(material);
            else if(i == 3)
                c.Refining(material);
        }
    }
}
