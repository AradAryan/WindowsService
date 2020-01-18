namespace MyFirstService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.myServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.myServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // myServiceProcessInstaller
            // 
            this.myServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.myServiceProcessInstaller.Password = null;
            this.myServiceProcessInstaller.Username = null;
            // 
            // myServiceInstaller
            // 
            this.myServiceInstaller.Description = "My Windows Service";
            this.myServiceInstaller.DisplayName = "MyUsageService";
            this.myServiceInstaller.ServiceName = "LogService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.myServiceProcessInstaller,
            this.myServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller myServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller myServiceInstaller;
    }
}