﻿namespace tomenglertde.ResXManager.VSIX.Visuals
{
    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;

    using JetBrains.Annotations;

    using tomenglertde.ResXManager.Infrastructure;

    using TomsToolbox.Wpf.Composition;

    /// <summary>
    /// Interaction logic for MoveToResourceConfigurationView.xaml
    /// </summary>
    [DataTemplate(typeof(MoveToResourceConfigurationViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class MoveToResourceConfigurationView
    {
        [ImportingConstructor]
        public MoveToResourceConfigurationView([NotNull] ExportProvider exportProvider)
        {
            try
            {
                this.SetExportProvider(exportProvider);

                InitializeComponent();
            }
            catch (Exception ex)
            {
                exportProvider.TraceXamlLoaderError(ex);
            }
        }
    }
}
