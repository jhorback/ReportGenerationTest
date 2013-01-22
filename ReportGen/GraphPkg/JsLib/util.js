var util = {
	
	printObject: function (object) {
		/// <summary>
		/// Provides visibility into an objects keys/values for debugging purposes.
		///</summary>
		var str = "";
		for (var key in object) {
			try {
				str += key + " : " + object[key] + "<br>";
			} catch (e) {
				str += key + " : error reading:<br>" + printObject(e);
			}
		}
		return str;
	},
	
	bool: function (value) {
		if (String(value) === "True") {
			return true;
		}
		if (String(value) === "False") {
			return false;
		}
		return value;
	}
};