"""Ensure rule comparison notices arithmetic and eligibility changes."""
import unittest

import audit_score_streak_provenance as audit


class ScoreStreakProvenanceTests(unittest.TestCase):
    def setUp(self):
        rules = "killStreakProgress -= decay; if (killStreakProgress > 100f) { Grant(); }"
        online = "public override bool dropCreates { get { return level > 4; } }"
        self.previous = {"ScoreManager": "protected void Update() { " + rules + "mTimeFromStart += dt; }",
                         "GameControllerOnline": online}
        self.current = {"ScoreManager": "private const float KillStreakThreshold = 100f;"
                        "private void AdvanceLocalStreak() { if (IsSelfHostedScoreActive) { return; }"
                        + rules.replace("100f", "KillStreakThreshold") + "}", "GameControllerOnline": online}

    def test_guarded_extraction_preserves_rules(self):
        audit.verify_rules(self.previous, self.current)

    def test_changed_threshold_comparison_is_rejected(self):
        self.current["ScoreManager"] = self.current["ScoreManager"].replace("> KillStreakThreshold", ">= KillStreakThreshold")
        with self.assertRaisesRegex(ValueError, "arithmetic"):
            audit.verify_rules(self.previous, self.current)

    def test_changed_eligibility_is_rejected(self):
        self.current["GameControllerOnline"] = self.current["GameControllerOnline"].replace("level > 4", "level >= 4")
        with self.assertRaisesRegex(ValueError, "eligibility"):
            audit.verify_rules(self.previous, self.current)


if __name__ == "__main__":
    unittest.main()
