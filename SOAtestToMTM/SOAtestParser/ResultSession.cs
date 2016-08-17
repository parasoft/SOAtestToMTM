/// Class generated from SOAtest report xml with Parse Special
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class ResultsSession {
    
    private ResultsSessionTestConfig testConfigField;
    
    private ResultsSessionAuthors authorsField;
    
    private ResultsSessionStorageInfo[] versionInfosField;
    
    private ResultsSessionExecutedTestsDetails executedTestsDetailsField;
    
    private ResultsSessionScope scopeField;
    
    private ResultsSessionFunctionalTests functionalTestsField;
    
    private ResultsSessionTag[] assocUrlsField;
    
    private string buildIdField;
    
    private string dateField;
    
    private string projectField;
    
    private string tagField;
    
    private System.DateTime timeField;
    
    private string toolNameField;
    
    private string toolVerField;
    
    /// <remarks/>
    public ResultsSessionTestConfig TestConfig {
        get {
            return this.testConfigField;
        }
        set {
            this.testConfigField = value;
        }
    }
    
    /// <remarks/>
    public ResultsSessionAuthors Authors {
        get {
            return this.authorsField;
        }
        set {
            this.authorsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("StorageInfo", IsNullable=false)]
    public ResultsSessionStorageInfo[] VersionInfos {
        get {
            return this.versionInfosField;
        }
        set {
            this.versionInfosField = value;
        }
    }
    
    /// <remarks/>
    public ResultsSessionExecutedTestsDetails ExecutedTestsDetails {
        get {
            return this.executedTestsDetailsField;
        }
        set {
            this.executedTestsDetailsField = value;
        }
    }
    
    /// <remarks/>
    public ResultsSessionScope Scope {
        get {
            return this.scopeField;
        }
        set {
            this.scopeField = value;
        }
    }
    
    /// <remarks/>
    public ResultsSessionFunctionalTests FunctionalTests {
        get {
            return this.functionalTestsField;
        }
        set {
            this.functionalTestsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Tag", IsNullable=false)]
    public ResultsSessionTag[] AssocUrls {
        get {
            return this.assocUrlsField;
        }
        set {
            this.assocUrlsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string buildId {
        get {
            return this.buildIdField;
        }
        set {
            this.buildIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string date {
        get {
            return this.dateField;
        }
        set {
            this.dateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string project {
        get {
            return this.projectField;
        }
        set {
            this.projectField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tag {
        get {
            return this.tagField;
        }
        set {
            this.tagField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime time {
        get {
            return this.timeField;
        }
        set {
            this.timeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string toolName {
        get {
            return this.toolNameField;
        }
        set {
            this.toolNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string toolVer {
        get {
            return this.toolVerField;
        }
        set {
            this.toolVerField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionTestConfig {
    
    private string machineField;
    
    private string nameField;
    
    private string pseudoUrlField;
    
    private string userField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string machine {
        get {
            return this.machineField;
        }
        set {
            this.machineField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string pseudoUrl {
        get {
            return this.pseudoUrlField;
        }
        set {
            this.pseudoUrlField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string user {
        get {
            return this.userField;
        }
        set {
            this.userField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionAuthors {
    
    private ResultsSessionAuthorsAuthor authorField;
    
    /// <remarks/>
    public ResultsSessionAuthorsAuthor Author {
        get {
            return this.authorField;
        }
        set {
            this.authorField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionAuthorsAuthor {
    
    private string idField;
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionStorageInfo {
    
    private string ownerIdField;
    
    private string resultIdField;
    
    private byte verField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ownerId {
        get {
            return this.ownerIdField;
        }
        set {
            this.ownerIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string resultId {
        get {
            return this.resultIdField;
        }
        set {
            this.resultIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte ver {
        get {
            return this.verField;
        }
        set {
            this.verField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionExecutedTestsDetails {
    
    private ResultsSessionExecutedTestsDetailsTotal totalField;
    
    /// <remarks/>
    public ResultsSessionExecutedTestsDetailsTotal Total {
        get {
            return this.totalField;
        }
        set {
            this.totalField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionExecutedTestsDetailsTotal {
    
    private ResultsSessionExecutedTestsDetailsTotalProject projectField;
    
    private string authChangeField;
    
    private string authFailField;
    
    private byte changeField;
    
    private byte changePassField;
    
    private byte changeTotalField;
    
    private byte failField;
    
    private string nameField;
    
    private byte passField;
    
    private string timeField;
    
    private byte totalField;
    
    /// <remarks/>
    public ResultsSessionExecutedTestsDetailsTotalProject Project {
        get {
            return this.projectField;
        }
        set {
            this.projectField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authChange {
        get {
            return this.authChangeField;
        }
        set {
            this.authChangeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authFail {
        get {
            return this.authFailField;
        }
        set {
            this.authFailField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte change {
        get {
            return this.changeField;
        }
        set {
            this.changeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changePass {
        get {
            return this.changePassField;
        }
        set {
            this.changePassField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changeTotal {
        get {
            return this.changeTotalField;
        }
        set {
            this.changeTotalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte fail {
        get {
            return this.failField;
        }
        set {
            this.failField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte pass {
        get {
            return this.passField;
        }
        set {
            this.passField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string time {
        get {
            return this.timeField;
        }
        set {
            this.timeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte total {
        get {
            return this.totalField;
        }
        set {
            this.totalField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionExecutedTestsDetailsTotalProject {
    
    private ResultsSessionExecutedTestsDetailsTotalProjectTestSuite testSuiteField;
    
    private string authChangeField;
    
    private string authFailField;
    
    private byte changeField;
    
    private byte changePassField;
    
    private byte changeTotalField;
    
    private byte failField;
    
    private string nameField;
    
    private byte passField;
    
    private string timeField;
    
    private byte totalField;
    
    /// <remarks/>
    public ResultsSessionExecutedTestsDetailsTotalProjectTestSuite TestSuite {
        get {
            return this.testSuiteField;
        }
        set {
            this.testSuiteField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authChange {
        get {
            return this.authChangeField;
        }
        set {
            this.authChangeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authFail {
        get {
            return this.authFailField;
        }
        set {
            this.authFailField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte change {
        get {
            return this.changeField;
        }
        set {
            this.changeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changePass {
        get {
            return this.changePassField;
        }
        set {
            this.changePassField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changeTotal {
        get {
            return this.changeTotalField;
        }
        set {
            this.changeTotalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte fail {
        get {
            return this.failField;
        }
        set {
            this.failField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte pass {
        get {
            return this.passField;
        }
        set {
            this.passField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string time {
        get {
            return this.timeField;
        }
        set {
            this.timeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte total {
        get {
            return this.totalField;
        }
        set {
            this.totalField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionExecutedTestsDetailsTotalProjectTestSuite {
    
    private ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuite testSuiteField;
    
    private string authChangeField;
    
    private string authFailField;
    
    private byte changeField;
    
    private byte changePassField;
    
    private byte changeTotalField;
    
    private byte failField;
    
    private string idField;
    
    private string nameField;
    
    private byte passField;
    
    private string timeField;
    
    private byte totalField;
    
    /// <remarks/>
    public ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuite TestSuite {
        get {
            return this.testSuiteField;
        }
        set {
            this.testSuiteField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authChange {
        get {
            return this.authChangeField;
        }
        set {
            this.authChangeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authFail {
        get {
            return this.authFailField;
        }
        set {
            this.authFailField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte change {
        get {
            return this.changeField;
        }
        set {
            this.changeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changePass {
        get {
            return this.changePassField;
        }
        set {
            this.changePassField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changeTotal {
        get {
            return this.changeTotalField;
        }
        set {
            this.changeTotalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte fail {
        get {
            return this.failField;
        }
        set {
            this.failField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte pass {
        get {
            return this.passField;
        }
        set {
            this.passField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string time {
        get {
            return this.timeField;
        }
        set {
            this.timeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte total {
        get {
            return this.totalField;
        }
        set {
            this.totalField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuite {
    
    private ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuiteTestSuite[] testSuiteField;
    
    private string authField;
    
    private string authChangeField;
    
    private string authFailField;
    
    private byte changeField;
    
    private byte changePassField;
    
    private byte changeTotalField;
    
    private byte failField;
    
    private string idField;
    
    private string nameField;
    
    private byte passField;
    
    private bool rootField;
    
    private string timeField;
    
    private byte totalField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TestSuite")]
    public ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuiteTestSuite[] TestSuite {
        get {
            return this.testSuiteField;
        }
        set {
            this.testSuiteField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string auth {
        get {
            return this.authField;
        }
        set {
            this.authField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authChange {
        get {
            return this.authChangeField;
        }
        set {
            this.authChangeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authFail {
        get {
            return this.authFailField;
        }
        set {
            this.authFailField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte change {
        get {
            return this.changeField;
        }
        set {
            this.changeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changePass {
        get {
            return this.changePassField;
        }
        set {
            this.changePassField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changeTotal {
        get {
            return this.changeTotalField;
        }
        set {
            this.changeTotalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte fail {
        get {
            return this.failField;
        }
        set {
            this.failField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte pass {
        get {
            return this.passField;
        }
        set {
            this.passField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool root {
        get {
            return this.rootField;
        }
        set {
            this.rootField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string time {
        get {
            return this.timeField;
        }
        set {
            this.timeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte total {
        get {
            return this.totalField;
        }
        set {
            this.totalField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuiteTestSuite {
    
    private ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuiteTestSuiteTest[] testField;
    
    private string authField;
    
    private string authChangeField;
    
    private string authFailField;
    
    private byte changeField;
    
    private byte changePassField;
    
    private byte changeTotalField;
    
    private byte failField;
    
    private string idField;
    
    private string nameField;
    
    private byte passField;
    
    private string timeField;
    
    private byte totalField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Test")]
    public ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuiteTestSuiteTest[] Test {
        get {
            return this.testField;
        }
        set {
            this.testField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string auth {
        get {
            return this.authField;
        }
        set {
            this.authField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authChange {
        get {
            return this.authChangeField;
        }
        set {
            this.authChangeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authFail {
        get {
            return this.authFailField;
        }
        set {
            this.authFailField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte change {
        get {
            return this.changeField;
        }
        set {
            this.changeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changePass {
        get {
            return this.changePassField;
        }
        set {
            this.changePassField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changeTotal {
        get {
            return this.changeTotalField;
        }
        set {
            this.changeTotalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte fail {
        get {
            return this.failField;
        }
        set {
            this.failField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte pass {
        get {
            return this.passField;
        }
        set {
            this.passField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string time {
        get {
            return this.timeField;
        }
        set {
            this.timeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte total {
        get {
            return this.totalField;
        }
        set {
            this.totalField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuiteTestSuiteTest {
    
    private ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuiteTestSuiteTestAssoc[] assocField;
    
    private string authField;
    
    private string authChangeField;
    
    private string authFailField;
    
    private byte changeField;
    
    private byte changePassField;
    
    private byte changeTotalField;
    
    private byte failField;
    
    private string idField;
    
    private string nameField;
    
    private byte passField;
    
    private ulong startTimeField;
    
    private string timeField;
    
    private string toolField;
    
    private byte totalField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("assoc")]
    public ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuiteTestSuiteTestAssoc[] assoc {
        get {
            return this.assocField;
        }
        set {
            this.assocField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string auth {
        get {
            return this.authField;
        }
        set {
            this.authField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authChange {
        get {
            return this.authChangeField;
        }
        set {
            this.authChangeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string authFail {
        get {
            return this.authFailField;
        }
        set {
            this.authFailField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte change {
        get {
            return this.changeField;
        }
        set {
            this.changeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changePass {
        get {
            return this.changePassField;
        }
        set {
            this.changePassField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte changeTotal {
        get {
            return this.changeTotalField;
        }
        set {
            this.changeTotalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte fail {
        get {
            return this.failField;
        }
        set {
            this.failField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte pass {
        get {
            return this.passField;
        }
        set {
            this.passField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ulong startTime {
        get {
            return this.startTimeField;
        }
        set {
            this.startTimeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string time {
        get {
            return this.timeField;
        }
        set {
            this.timeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tool {
        get {
            return this.toolField;
        }
        set {
            this.toolField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte total {
        get {
            return this.totalField;
        }
        set {
            this.totalField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionExecutedTestsDetailsTotalProjectTestSuiteTestSuiteTestSuiteTestAssoc {
    
    private ushort idField;
    
    private string tagField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tag {
        get {
            return this.tagField;
        }
        set {
            this.tagField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionScope {
    
    private ResultsSessionScopeProjectInformations projectInformationsField;
    
    /// <remarks/>
    public ResultsSessionScopeProjectInformations ProjectInformations {
        get {
            return this.projectInformationsField;
        }
        set {
            this.projectInformationsField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionScopeProjectInformations {
    
    private ResultsSessionScopeProjectInformationsScopeProjectInfo scopeProjectInfoField;
    
    /// <remarks/>
    public ResultsSessionScopeProjectInformationsScopeProjectInfo ScopeProjectInfo {
        get {
            return this.scopeProjectInfoField;
        }
        set {
            this.scopeProjectInfoField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionScopeProjectInformationsScopeProjectInfo {
    
    private byte fltFilesField;
    
    private byte fltLnsField;
    
    private string projectField;
    
    private byte totFilesField;
    
    private byte totLnsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte fltFiles {
        get {
            return this.fltFilesField;
        }
        set {
            this.fltFilesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte fltLns {
        get {
            return this.fltLnsField;
        }
        set {
            this.fltLnsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string project {
        get {
            return this.projectField;
        }
        set {
            this.projectField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte totFiles {
        get {
            return this.totFilesField;
        }
        set {
            this.totFilesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte totLns {
        get {
            return this.totLnsField;
        }
        set {
            this.totLnsField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionFunctionalTests {
    
    private ResultsSessionFunctionalTestsGoal[] goalsField;
    
    private ResultsSessionFunctionalTestsFuncViol[] funcViolsField;
    
    private ResultsSessionFunctionalTestsCategory[] categoriesField;
    
    private string ownerIdField;
    
    private string timeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Goal", IsNullable=false)]
    public ResultsSessionFunctionalTestsGoal[] Goals {
        get {
            return this.goalsField;
        }
        set {
            this.goalsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("FuncViol", IsNullable=false)]
    public ResultsSessionFunctionalTestsFuncViol[] FuncViols {
        get {
            return this.funcViolsField;
        }
        set {
            this.funcViolsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Category", IsNullable=false)]
    public ResultsSessionFunctionalTestsCategory[] Categories {
        get {
            return this.categoriesField;
        }
        set {
            this.categoriesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ownerId {
        get {
            return this.ownerIdField;
        }
        set {
            this.ownerIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string time {
        get {
            return this.timeField;
        }
        set {
            this.timeField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionFunctionalTestsGoal {
    
    private byte modeField;
    
    private string nameField;
    
    private byte typeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte mode {
        get {
            return this.modeField;
        }
        set {
            this.modeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionFunctionalTestsFuncViol {
    
    private byte sevField;
    
    private sbyte lnField;
    
    private byte catField;
    
    private string toolField;
    
    private string taskTypeField;
    
    private string requestTrafficBodyField;
    
    private string langField;
    
    private string requestTrafficMIMETypeField;
    
    private byte configField;
    
    private string responseTrafficBodyField;
    
    private string chainedToolIdField;
    
    private uint hashField;
    
    private bool urgentField;
    
    private bool fatalField;
    
    private string responseTrafficMIMETypeField;
    
    private string locTypeField;
    
    private string responseTrafficHeadersField;
    
    private string violationDetailsField;
    
    private string msgField;
    
    private string testCaseIdField;
    
    private string requestTrafficHeadersField;
    
    private string authField;
    
    private string locFileField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte sev {
        get {
            return this.sevField;
        }
        set {
            this.sevField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public sbyte ln {
        get {
            return this.lnField;
        }
        set {
            this.lnField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte cat {
        get {
            return this.catField;
        }
        set {
            this.catField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tool {
        get {
            return this.toolField;
        }
        set {
            this.toolField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string taskType {
        get {
            return this.taskTypeField;
        }
        set {
            this.taskTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string requestTrafficBody {
        get {
            return this.requestTrafficBodyField;
        }
        set {
            this.requestTrafficBodyField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lang {
        get {
            return this.langField;
        }
        set {
            this.langField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string requestTrafficMIMEType {
        get {
            return this.requestTrafficMIMETypeField;
        }
        set {
            this.requestTrafficMIMETypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte config {
        get {
            return this.configField;
        }
        set {
            this.configField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string responseTrafficBody {
        get {
            return this.responseTrafficBodyField;
        }
        set {
            this.responseTrafficBodyField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string chainedToolId {
        get {
            return this.chainedToolIdField;
        }
        set {
            this.chainedToolIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint hash {
        get {
            return this.hashField;
        }
        set {
            this.hashField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool urgent {
        get {
            return this.urgentField;
        }
        set {
            this.urgentField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool fatal {
        get {
            return this.fatalField;
        }
        set {
            this.fatalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string responseTrafficMIMEType {
        get {
            return this.responseTrafficMIMETypeField;
        }
        set {
            this.responseTrafficMIMETypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string locType {
        get {
            return this.locTypeField;
        }
        set {
            this.locTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string responseTrafficHeaders {
        get {
            return this.responseTrafficHeadersField;
        }
        set {
            this.responseTrafficHeadersField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string violationDetails {
        get {
            return this.violationDetailsField;
        }
        set {
            this.violationDetailsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string msg {
        get {
            return this.msgField;
        }
        set {
            this.msgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string testCaseId {
        get {
            return this.testCaseIdField;
        }
        set {
            this.testCaseIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string requestTrafficHeaders {
        get {
            return this.requestTrafficHeadersField;
        }
        set {
            this.requestTrafficHeadersField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string auth {
        get {
            return this.authField;
        }
        set {
            this.authField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string locFile {
        get {
            return this.locFileField;
        }
        set {
            this.locFileField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionFunctionalTestsCategory {
    
    private ResultsSessionFunctionalTestsCategorySubCategory[] subCategoryField;
    
    private string descField;
    
    private byte idField;
    
    private string labelField;
    
    private string label0Field;
    
    private string label1Field;
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SubCategory")]
    public ResultsSessionFunctionalTestsCategorySubCategory[] SubCategory {
        get {
            return this.subCategoryField;
        }
        set {
            this.subCategoryField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string desc {
        get {
            return this.descField;
        }
        set {
            this.descField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string label {
        get {
            return this.labelField;
        }
        set {
            this.labelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string label0 {
        get {
            return this.label0Field;
        }
        set {
            this.label0Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string label1 {
        get {
            return this.label1Field;
        }
        set {
            this.label1Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionFunctionalTestsCategorySubCategory {
    
    private byte idField;
    
    private string nameField;
    
    private string shortField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string @short {
        get {
            return this.shortField;
        }
        set {
            this.shortField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ResultsSessionTag {
    
    private string dispField;
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string disp {
        get {
            return this.dispField;
        }
        set {
            this.dispField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

