var util = {
	
	printObject: function (object) {
		/// <summary>
		/// Provides visibility into an objects keys/values for debugging purposes.
		///</summary>
		var str = "";
		for (var key in object) {
			try {
				str += " -------------------- " + key + " : " + object[key];
			} catch (e) {
				str += " -------------------- " + key + " : error reading - " + printObject(e);
			}
		}
		return str;
	}
};