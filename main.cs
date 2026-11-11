public class Solution {
    public int MaxEnvelopes(int[][] envelopes) {
        // Sort by width ascending; if widths are equal, sort by height descending.
        Array.Sort(envelopes, (a, b) => {
            if (a[0] != b[0]) {
                return a[0].CompareTo(b[0]);
            }
            return b[1].CompareTo(a[1]);
        });

        // Find the Longest Increasing Subsequence on heights
        List<int> dp = new List<int>();

        foreach (var env in envelopes) {
            int height = env[1];
            int idx = dp.BinarySearch(height);

            // If not found, BinarySearch returns ~index where it should be inserted
            if (idx < 0) {
                idx = ~idx;
            }

            if (idx == dp.Count) {
                dp.Add(height);
            } else {
                dp[idx] = height;
            }
        }

        return dp.Count;
    }
}
