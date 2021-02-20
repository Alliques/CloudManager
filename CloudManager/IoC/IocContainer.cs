using Ninject;

namespace CloudManager
{
    public static class IoC
    {
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
        public static void Setup()
        {
            BindViewModels();
        }

        /// <summary>
        /// Binds all singletone view models
        /// </summary>
        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
    }
}
