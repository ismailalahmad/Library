namespace LibraryManagement1.Controller
{
    public interface IController
    {
        public void Add();
        public void Add(List<Object> list);
        public void Remove();
        public void Remove(int Id);
        public void Update();
        public void Update(int Id);
        public void Get();
        public void Get(int Id);

    }
}
