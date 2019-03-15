using System;
using System.Windows.Data;
using System.Windows.Media;

namespace GenealogyResearchApp.View.Convertors {
	public class ObjectToTypeConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			if (value == null) return null;
			if (value.GetType().Name.Contains("Test") || (value.GetType().FullName.Contains("System.Data.Entity.DynamicProxies"))) return value.GetType().BaseType.Name;
			return value.GetType().Name;

	}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			throw new InvalidOperationException();
		}
	}
}
