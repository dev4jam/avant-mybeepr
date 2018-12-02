--------------------------------- Part I -----------------------------------------------
Assuming we have a large number of records and we need to 
have an efficient way of reading this data I'd suggest three data structures:

1. Trie (prefix tree variation) built on full patients' names where 
each node would contain a full set of primary keys satisfying search criteria. 
Lookup complexity is O(m) where m is the length of a search phrase. But it 
eats up memory very quickly. For this concern, I might think of compressed 
trie.

Pros: allows search starting from any character in the full name.

2. Hashmap. Similar to trie. But lookup complexity is O(1). Insert in average is O(1) 
but O(n) in the worst case when n elements are resolved to the same hash key.

Pros: fastest lookup. Cons: requires full search term match.

3. B-Tree (self-balanced tree) where each node corresponds to a full patient's name
and contains a set of matched primary keys. Lookup complexity in the worst and average 
cases is O(log N) where N - is the number of all unique names. Insert and delete also
end up by O(log N) in both cases.

Pros: balanced lookup vs edit and memory allocated. Each node might contain 
more than 2 children nodes. And this fact is heavily utilized in database indexing
engines to read big blocks of data from disk. Cons: not the fastest lookup.  



--------------------------------- Part II ----------------------------------------------

My working days solution is based on a fact that we have 5 working days per week. 
So I simply extend given timeframe to a certain number of full weeks. Then I divide it 
by working days ratio  - 1.4 (7/5) to get a number of working days in a given timeframe.
And finally, I subtract the number of extra working days I've added on the first step. 
This solution allows calculating a number of working days between two dates in constant
time O(1) no matter how big the interval is.

--------------------------------- End --------------------------------------------------
