/// <reference path="Mocks/qunit.js" />
/// <reference path="../report1/report.combined.js" />
/// <reference path="Mocks/MockContext.js" />


QUnit.test("Report generation succeeds.", function () {
	var context	 = new MockContext();
	generateReport(context);
	QUnit.ok(true);
	
});


test("SignatureSrc is set in the template.", function () {
	var context, actual, expected;

	context	 = new MockContext();
	generateReport(context);
	actual = context.template.get("SignatureSrc");
	expected = "MockImageSource";
	
	QUnit.equal(actual, expected);
});


test("Test message logged.", function () {
	var context, actual, expected;

	context	 = new MockContext();
	generateReport(context);
	actual = context.logger.getLog().length;
	expected = 1;

	QUnit.ok(actual >= expected);
});


test("Generation exception caught and logged.", function () {
	var context, actual, expected;

	debugger;
	context	 = new MockContext();
	context.template.put("GenerateError", "True");
	generateReport(context);
	
	actual = context.logger.getLog()[0];
	expected = "An error occured during report generation: Testing errors caused by report generation.";
	QUnit.equal(actual, expected);
});