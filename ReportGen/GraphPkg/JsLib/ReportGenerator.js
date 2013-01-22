(function (root, _) {	
	
	var generateReport, ReportGeneratorReportGenerator;

	generateReport = function (context) {
		// Audit(), Helper(), Template()
		var gen = new ReportGenerator(context);
		
		try {
			gen.generate();
		} catch (e) {
			gen.logger.log("An error occured during report generation: " + e.message);
		}
	};

	ReportGenerator = function (options) {
		this.audit = options.get_audit();
		this.helper = options.get_helper();
		this.template = options.get_template();
		this.logger = options.get_logger();
	};

	ReportGenerator.prototype = {
		generate: function () {
			throw new Error("The generate method was not implemented.");
		}
	};
	
	ReportGenerator.extend = function (extension) {
		_.extend(ReportGenerator.prototype, extension);
	};

	root.ReportGenerator = ReportGenerator;
	root.generateReport = generateReport;

})(this, _);
