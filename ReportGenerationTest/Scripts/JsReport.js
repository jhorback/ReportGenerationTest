
var generateReport = function (context, stringVal, intVal) {

//	var str = "";
//	for (var prop in context) {
//		str += prop + ": " + context[prop] + "\n";
//	}
//	return str;
	// context._Name = "george";
	return "hello world - " + context.get_Name() + " - " + context.get_Description() + " - " +
		context.GetModifiedDescription(stringVal, intVal);
	
};