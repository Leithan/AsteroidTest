using UnityEngine;

public class GenericFactory
{
   public GameObject Create<T,U>(GameObject prefab, Vector3 position) where T : IModelView where U : IController, new()
   {
      var instance = Object.Instantiate(prefab);
      var modelView = instance.GetComponent<T>();
      modelView.Position = position;
      modelView.SetController(new U());
      return instance;
   }
}