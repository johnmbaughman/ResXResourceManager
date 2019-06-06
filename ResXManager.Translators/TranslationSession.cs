﻿namespace tomenglertde.ResXManager.Translators
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;

    using JetBrains.Annotations;

    using tomenglertde.ResXManager.Infrastructure;

    using TomsToolbox.Desktop;

    public class TranslationSession : ObservableObject, ITranslationSession
    {
        [NotNull]
        [ItemNotNull]
        private readonly ObservableCollection<string> _internalMessage = new ObservableCollection<string>();

        public TranslationSession([CanBeNull] CultureInfo sourceLanguage, [NotNull] CultureInfo neutralResourcesLanguage, [NotNull][ItemNotNull] ICollection<ITranslationItem> items)
        {
            SourceLanguage = sourceLanguage ?? neutralResourcesLanguage;
            NeutralResourcesLanguage = neutralResourcesLanguage;
            Items = items;

            Messages = new ReadOnlyObservableCollection<string>(_internalMessage);
        }

        public CultureInfo SourceLanguage { get; }

        public CultureInfo NeutralResourcesLanguage { get; }

        public ICollection<ITranslationItem> Items { get; }

        public bool IsCanceled { get; private set; }

        public int Progress { get; set; }

        public bool IsComplete { get; set; }

        public bool IsActive => !IsComplete;

        public IList<string> Messages { get; }

        public void AddMessage(string text)
        {
            Dispatcher.BeginInvoke(() => _internalMessage.Add(text));
        }

        public void Cancel()
        {
            IsCanceled = true;
        }
    }
}
