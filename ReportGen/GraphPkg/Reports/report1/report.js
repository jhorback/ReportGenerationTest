ReportGenerator.extend({
	generate: function () {

		this.contextTest();
		this.logMessageTest();
		this.generateErrorTest();
		
	},
	
	contextTest: function () {
		var sigBytes = this.audit.GetSignature().get_Content();
		var sigSrc = this.helper.GetImageSrc(sigBytes);
		this.template.put("SignatureSrc", sigSrc);
	},
	
	logMessageTest: function () {
		this.logger.log("Here is a log message");
	},
	
	generateErrorTest: function () {
		var generateError = this.template.get("GenerateError");
		this.logger.log("Generate Error: " + generateError);
		if (util.bool(generateError) === true) {
			throw new Error("Testing errors caused by report generation.");
		}
	}
});