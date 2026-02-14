namespace Shop_mvc_pv421.Interfaces
{
    public interface IViewRender
    {
        string Render<TModel>(string name, TModel model);
    }
}
