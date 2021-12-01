import React from "react";

function FooterElement() {
    return (

        // <!-- footer -->
        <footer className="dashFooterBox">
            <div className="dashFooterBoxInner">
                {/* <!-- footer button --> */}
                <div className="dashFooterBtn">
                    <label htmlFor="show-foot"><i className="fas fa-code"></i></label>
                </div>
                {/* <!-- end footer button -->
    <!-- footer --> */}
                <input type="checkbox" id="show-foot" name="show-the-footer" className="r-foot-check"></input>
                <nav className="dashFooter">
                    <div className="default-width">
                        <div className="dashFooterInner">
                            <ul className="footNavUL">
                                <li><i className="fas fa-users"></i></li>
                                <li>Made</li>
                                <li>By</li>
                                <li>MedMax</li>
                                <li>2021</li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
        </footer>

    );
};
export default FooterElement;