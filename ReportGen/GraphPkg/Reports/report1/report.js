

var generateReport = function (context) {

	context.get_Template().put("Debug", "foo1");

	
	context._Template.put("Client", {
		Name: context.get_Audit().get_ClientName()
	});

	var sigBytes = context.get_Audit().GetSignature().get_Content();
	var sigSrc = context.get_Helper().GetImageSrc(sigBytes);
	context.get_Template().put("SignatureSrc", sigSrc);
};